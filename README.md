# Tarea Extraclase 2 - Retos con Listas Enlazadas

Este repositorio contiene la implementación y pruebas unitarias de los tres problemas planteados sobre listas doblemente enlazadas, como parte de la **Tarea Extraclase 2** del curso de Algoritmos y Estructuras de Datos I en el Instituto Tecnológico de Costa Rica.

## Objetivos

### General
- Resolver problemas utilizando listas enlazadas en C#.

### Específicos
- Implementar problemas conocidos sobre listas enlazadas.
- Crear pruebas unitarias utilizando MSTest.
- Manejar excepciones en los algoritmos.

## Problemas Resueltos

### 1. Mezclar en Orden (`MergeSorted`)
Mezcla dos listas doblemente enlazadas en orden ascendente o descendente según lo indicado por el argumento `SortDirection`.

### 2. Invertir Lista (`InvertList`)
Invierte una lista doblemente enlazada sin crear una nueva lista.

### 3. Obtener el Elemento Central (`GetMiddle`)
Obtiene el elemento central de la lista con un solo acceso a memoria, sin recorrer toda la lista.

## Pruebas Unitarias

Se implementaron pruebas unitarias con MSTest para cada uno de los problemas:

- **Pruebas para `MergeSorted`**: Casos de mezcla ascendente y descendente, manejo de listas nulas y vacías.
- **Pruebas para `InvertList`**: Verificación de la inversión de listas con diferentes tamaños y manejo de excepciones.
- **Pruebas para `GetMiddle`**: Casos de listas vacías, con un solo elemento, y listas con un número par e impar de elementos.

## Requisitos

- **.NET 8 y C# 12**
