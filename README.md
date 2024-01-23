# QuestPDF


## Pasos


###### Instalar

```
dotnet tool install QuestPDF.Previewer --global
```

###### Abrir Previewer


```
questpdf-previewer
```

###### Ejecutar api


```
dotnet run
```

###### Llamar /generatePDF

Luego de esto recien se va a mostrar el PDF. Esto es por que el metodo que genera el previewer esta dentro de este metodo

```
app.MapGet("/generatePDF", () =>
{
    CreatePDF.GeneratePdf();
});
```

Si se lo llama por fuera de este metodo no es necesario llamar a la api.

El metodo es infinito debido a este codigo, que es lo que permite ver el PDF en el previewer. Sin este codigo solo genera el PDF y termina el metodo.

```
// use the following invocation
document.ShowInPreviewer();
```


