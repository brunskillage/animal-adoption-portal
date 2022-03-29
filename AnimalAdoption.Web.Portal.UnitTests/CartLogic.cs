using AnimalAdoption.Common.Logic;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using Xunit;

namespace AnimalAdoption.Service.Cart.UnitTests
{
    public class CartTests
    {
        [Fact(Skip="Chrome driver missing")]
        public void CartManagement_EmptyCartAddAnimal_AnAnimalIsAdded()
        {
            var animalId = 1;
            var quantityAmount = 1;

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var resultingCart = new CartService(memoryCache, new AnimalService()).SetAnimalQuantity("TEST_CART", animalId, quantityAmount);

            Assert.Equal("TEST_CART", resultingCart.Id);
            Assert.Equal(1, resultingCart.CartContents.First(x=>x.Id == animalId).Quantity);
        }

        [Fact(Skip="Chrome driver missing")]
        public void CartManagement_EmptyCartAddNegativeAnimal_AnAnimalDoesNotGoIntoNegative()
        {
            var animalId = 1;
            var quantityAmount = -1;

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var resultingCart = new CartService(memoryCache, new AnimalService()).SetAnimalQuantity("TEST_CART", animalId, quantityAmount);

            Assert.Equal("TEST_CART", resultingCart.Id);
            Assert.Equal(0, resultingCart.CartContents.First(x => x.Id == animalId).Quantity);
        }
    }
}
