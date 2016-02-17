using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PrestamosServicios.Dominio;
using PrestamosServicios.Persistencia;

namespace PrestamosServicios
{
    public class Categorias : ICategorias
    {
        private CategoriaDAO categoriaDAO = null;
        private CategoriaDAO CategoriaDAO
        {
            get
            {
                if (categoriaDAO == null)
                    categoriaDAO = new CategoriaDAO();
                return categoriaDAO;
            }
        }

        public Categoria CrearCategoria(string categoria)
        {
            Categoria categoriaACrear = new Categoria()
            {
                Category = categoria,
            };
            return CategoriaDAO.Crear(categoriaACrear);
        }

        public void EliminarCategoria(int codigo)
        {
            Categoria categoriaExistente = CategoriaDAO.Obtener(codigo);
            CategoriaDAO.Eliminar(categoriaExistente);
        }

        public List<Categoria> ListarCategoria()
        {
            return CategoriaDAO.ListarTodos().ToList();
        }

        public Categoria ModificarCategoria(int codigo, string categoria)
        {
            Categoria categoriaAModificar = new Categoria()
            {
                Codigo = codigo,
                Category = categoria,
            };
            return CategoriaDAO.Modificar(categoriaAModificar);
        }

        public Categoria ObtenerCategoria(int codigo)
        {
            return CategoriaDAO.Obtener(codigo);
        }
    }
}
