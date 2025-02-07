Saludos ing. Mauricio.

Estuve desde el miercoles por la tardenoche tratando de resolver un problema con la generación de codigo de las vistas y controladores debido al siguiente error: "No hay proveedores de scaffolding compatibles para este elemento".

Tras verificar que todos los paquetes de NuGet estaban instalados en su versión correspondiente me di por investigar más a fondo y tal parece que es un bug no tan raro del Visual Studio (adjunto evidencia): https://stackoverflow.com/questions/56205382/there-are-no-scaffolders-supported-for-this-item-visual-studio-2019

Personalmente no tuve exito con ninguna de las sugerencias, así que simplemente borré mi versión actual del Visual Studio, lo reinstalé, volví a hacer las migraciones y todo el proyecto en sí, y se solucionó.

Más que todo me costó tiempo volver a instalar los paquetes del Visual Studio.
