

namespace EnumDropDownListBindingSample.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class OrderEntity : BindableBase
    {
        private string customerName;
        private IEnumerable<Fruit> fruits = new List<Fruit>();
        private Fruit favorite;


        public string CustomerName
        {
            get { return this.customerName; }
            set { SetProperty(ref this.customerName, value); }
        }

        public IEnumerable<Fruit> Fruits
        {
            get { return this.fruits; }
            set { SetProperty(ref this.fruits, value); }
        }
        public Fruit Favorite
        {
            get { return this.favorite; }
            set { SetProperty(ref this.favorite, value); }
        }
    }
}
