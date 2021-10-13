using Microsoft.AspNetCore.Mvc;
using System;
using WorldJourney.Controllers;
using Xunit;

namespace WorldJourney.Tests.Unit
{
    public class CityControllerSpec
    {
        [Fact]
        public void DeveRetornarDetalhesDaCidadeParametrizada()
        {
            // Given
            var data = new DataMock();
            var cityController = new CityController(data);

            // When
            var resultado = cityController.Details(1);

            // Then
            Assert.True(resultado.GetType() == typeof(ViewResult));
            Assert.NotNull(((ViewResult)resultado).Model);
        }
    }
}
