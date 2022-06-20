using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class MyClassBLL
    {
        private Contexto _contexto;
        

        public MyClassBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Compras compra)
        {
            if (!Existe(compra.CompraId))
                return Insertar(compra);
            else
                return Modificar(compra);
        }

        private bool Insertar(Compras compra)
        {
            bool paso = false;

            try
            {
               
                if (_contexto.Compras.Add(compra) != null)
                    paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Modificar(Compras compra)
        {
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM ProductosDetalle WHERE ProductoId={compra.CompraId}");

                foreach (var Anterior in compra.Detalle)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }

                _contexto.Entry(compra).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Eliminar(int Id)
        {
            bool paso = false;

            try
            {
                var compra = _contexto.Compras.Find(Id);

                if (compra != null)
                {
                    _contexto.Compras.Remove(compra);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public Compras Buscar(int Id)
        {
            Compras compra;

            try
            {
                compra = _contexto.Compras.Include(x => x.Detalle).Where(c => c.CompraId == Id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return compra;
        }

        public bool Existe(string descripcion)
        {
            bool paso = false;

            try
            {
                paso = _contexto.Compras.Any(c => c.Descripcion == descripcion);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public bool Existe(int Id)
        {
            bool paso = false;

            try
            {
                paso = _contexto.Compras.Any(c => c.CompraId == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        
        public List<Compras> GetList(Expression<Func<Compras, bool>> compra)
        {
            List<Compras> lista = new List<Compras>();

            try
            {
                lista = _contexto.Compras.Where(compra).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<ComprasDetalle> GetListDetalle(Expression<Func<ComprasDetalle, bool>> compra)
        {
            List<ComprasDetalle> lista = new List<ComprasDetalle>();
            
            try
            {
                lista = _contexto.ComprasDetalles.Where(compra).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;

        }
       
    }
    