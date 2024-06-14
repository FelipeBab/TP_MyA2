using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Matrix<T> : IEnumerable<T>
{
    //IMPLEMENTAR: ESTRUCTURA INTERNA- DONDE GUARDO LOS DATOS?
    T[,] _Data;
    public Matrix(int width, int height)
    {
        //IMPLEMENTAR: constructor
        _Data = new T [width, height];
        Width = width;
        Height = height;
    }

	public Matrix(T[,] copyFrom)
    {
        //IMPLEMENTAR: crea una version de Matrix a partir de una matriz básica de C#
        for (int i = 0; i < copyFrom.GetLength(0); i++)
        {
            for (int j = 0; j < copyFrom.GetLength(1); j++)
            {
                _Data[i, j] = copyFrom[i, j];
            }
        }

        Width = copyFrom.GetLength(0);
        Height = copyFrom.GetLength(1);
    }

	public Matrix<T> Clone() {
        Matrix<T> aux = new Matrix<T>(Width, Height);
        //IMPLEMENTAR

        for (int i = 0; i < _Data.GetLength(0); i++)
        {
            for (int j = 0; j < _Data.GetLength(1); j++)
            {
                aux[i, j] = _Data[i, j];
            }
        }

        return aux;
    }

	public void SetRangeTo(int x0, int y0, int x1, int y1, T item) {
        //IMPLEMENTAR: iguala todo el rango pasado por parámetro a item
        for (int i = x0; i < x1; i++)
        {
            for (int j = y0; j < y1; j++)
            {
                _Data[i, j] = item;
            }
        }
    }

    //Todos los parametros son INCLUYENTES
    public List<T> GetRange(int x0, int y0, int x1, int y1) {
        List<T> l = new List<T>();
        //IMPLEMENTAR
        for (int i = x0; i < x1; i++)
        {
            for (int j = y0; j < y1; j++)
            {
                l.Add(_Data[i, j]);
            }
        }
        return l;
	}

    //Para poder igualar valores en la matrix a algo
    public T this[int x, int y] {
		get
        {
            //IMPLEMENTAR

            if (_Data[x,y] == null)
            {
                //throw new System.Exception("Null Matrix");
                return default(T);
            }

            return _Data[x,y];
		}
		set {
            //IMPLEMENTAR



		}
	}

    public int Width { get; private set; }

    public int Height { get; private set; }

    public int Capacity { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        List<T> l = new List<T>();
        //IMPLEMENTAR
        //foreach (var item in collection)
        //{

        //}

        for (int i = 0; i < _Data.GetLength(0); i++)
        {
            for (int j = 0; j < _Data.GetLength(1); j++)
            {
                l.Add(_Data[i, j]);
            }
        }

        yield return l;
    }

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}
}
