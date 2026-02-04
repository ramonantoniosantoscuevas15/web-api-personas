using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace web_api_personas.Utilidades
{
    public class TypeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombrepropiedad = bindingContext.ModelName;
            var valor = bindingContext.ValueProvider.GetValue(nombrepropiedad);

            if(valor == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            try
            {
                var tipoDestino = bindingContext.ModelMetadata.ModelType;
                var valorDeserializado = JsonSerializer.Deserialize(valor.FirstValue!,tipoDestino,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
                bindingContext.Result = ModelBindingResult.Success(valorDeserializado);
            }
            catch
            {
                bindingContext.ModelState.TryAddModelError(nombrepropiedad, "El valor proporcionado no es válido");
            } 
            return Task.CompletedTask;
        }
    }
}
