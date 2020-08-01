using System;
using System.Collections.Generic;
using GloryJewelleryApi.Models;

namespace GloryJewelleryApi.Services
{
    public interface IJewelleryService
    {
        public List<Jewellery> Get();

        public Jewellery Get(string id);

        public Jewellery Create(Jewellery jewellery);

        public void Update(string id, Jewellery newJewellery);

        public void Remove(string id);
    }
}
