using System;
using System.Collections.Generic;
using System.Text;

namespace KXamLab4.Repository
{
    public class DataAccess
    {
        private ProductRepository productRepository;
        public ProductRepository Product { get => productRepository; private set => productRepository = value; }
        private SellRepository sellRepository;
        public SellRepository Sell { get => sellRepository; private set => sellRepository = value; }
        private MakerRepository makerRepository;
        public MakerRepository Maker { get => makerRepository; private set => makerRepository = value; }

        public DataAccess(string datePath)
        {
            ProductRepository productRepository = new ProductRepository(datePath);
            this.productRepository = productRepository;
            SellRepository sellRepository = new SellRepository(datePath);
            this.sellRepository = sellRepository;
            MakerRepository makerRepository = new MakerRepository(datePath);
            this.makerRepository = makerRepository;
        }
    }
}
