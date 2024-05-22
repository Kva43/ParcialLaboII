﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Escaner
    {
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;

        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }

        public bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }

        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            listaDocumentos = new List<Documento>();

            if (tipo == TipoDoc.libro)
            {
                locacion = Departamento.procesosTecnicos;
            }
            else if (tipo == TipoDoc.mapa)
            {
                locacion = Departamento.mapoteca;
            }
            else
            {
                locacion = Departamento.nulo;
            }
        }

        public static bool operator !=(Escaner e1, Documento d)
        {
            return !(e1 == d);
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            // Itera a través de la lista de documentos del escáner
            foreach (Documento doc in e.listaDocumentos)
            {
                // Verifica si el documento actual es un libro
                if (doc is Libro libro1)
                {
                    // Verifica si el documento dado también es un libro
                    if (d is Libro libro2)
                    {
                        if (libro1 == libro2)
                        {
                            return true;
                        }
                    }
                }
                // Verifica si el documento actual es un mapa
                else if (doc is Mapa mapa1)
                {
                    // Verifica si el documento dado también es un mapa
                    if (d is Mapa mapa2)
                    {
                        if (mapa1 == mapa2)
                        {
                            return true;
                        }
                    }
                }
            }
            // Si no se encuentra un documento igual en la lista, devuelve false
            return false;
        }



        public static bool operator +(Escaner e1, Documento d)
        {
        }
    }

    enum Departamento
    {
        nulo, mapoteca, procesosTecnicos
    }

    enum TipoDoc
    {
        libro, mapa
    }
}
