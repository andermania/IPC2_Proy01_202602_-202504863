# ChapinWarriorsSA

Aplicación de escritorio **WinForms (.NET 10)** que simula misiones de rescate y combate en ciudades cuadriculadas. Lee configuraciones desde archivos XML, elige un robot y ejecuta la misión sobre un grafo ortogonal con algoritmo **BFS**, mostrando el resultado y un historial de misiones.

## Requisitos

- .NET SDK 10 (Windows)
- [Graphviz](https://graphviz.org/) instalado y con su carpeta `bin` en el `PATH` (se usa `dot` para generar los mapas PNG).

## Cómo usar

1. Coloca los archivos `.xml` de configuración en la carpeta **`XMLfiles`** del proyecto (se copian junto al ejecutable al compilar).
2. Ejecuta la app → **"Cargar XML"**.
3. Selecciona una ciudad, el robot y el destino, y lanza la misión.
4. Revisa el reporte final o el **historial** de misiones.

## Formato del XML

La raíz es `<configuracion>` con `<listaCiudades>` y `<robots>`.

- Cada `<ciudad>` tiene `<nombre filas="N" columnas="M">`, N elementos `<fila numero="i">` (malla de caracteres entre comillas) y opcionales `<unidadMilitar fila columna>capacidad</unidadMilitar>`.
  - Caracteres de la malla: `*` bloqueado, ` ` camino, `E` entrada, `C` civil, `R` recurso.
- Cada `<robot>` tiene `<nombre tipo="ChapinFighter" capacidad="X">` o `<nombre tipo="ChapinRescue">`.

## Componentes principales

| Archivo | Responsabilidad |
| --- | --- |
| `XMLReader` | Lee y parsea todos los `.xml` de la carpeta, deduplicando ciudades/robots por nombre. |
| `Controller` | Orquesta datos, ejecuta misiones y consultas (ciudades, robots, destinos). |
| `MissionEngine` | BFS multi-fuente sobre el grafo ortogonal aplicando las reglas de combate. |
| `OrthogonalGrid` | Construye (a pedido) el grafo ortogonal desde la matriz `Cell[][]` de la ciudad. |
| `MakeGraphiz` | Genera el mapa PNG con la ruta resaltada usando Graphviz. |
| `MissionRenderer` | Centraliza la presentación compartida entre el reporte final y el historial. |
| `NavigationController` | Controla la navegación entre formularios (Vistas). |

## Tipos de robot

- **ChapinFighter**: combate. Puede cruzar bases militares si su salud actual supera la capacidad de la base; si no, la ruta queda bloqueada (misión imposible). **Destinos: celdas de tipo Recurso (R).**
- **ChapinRescue**: no combate; las bases militares son muros. **Destinos: celdas de tipo Civil (C).**

## Notas de diseño

- La ciudad interna `Cell[][]` no se modifica; el grafo ortogonal se construye bajo demanda por misión.
- El BFS parte desde **todas** las entradas de la ciudad a la vez; el reporte muestra el **punto de salida real** (primera celda del camino reconstruido).
- Al no existir ruta, un fighter simula el recorrido en serie por las bases para reportar las que pudo/no pudo destruir.
