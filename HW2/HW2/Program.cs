Sale s1 = new Sale();
Sale s2 = new Sale();
Sale s3 = new Sale();

Sale[] sales = { s1, s2, s3 };


//q1
var q1 = from sale in sales
         where sale.PricePerItem > 10.0
         select sale;

//q2
var q2 = from sale in sales
        where sale.Quantity == 1
        orderby sale.PricePerItem descending
        select sale;

//q3
var q3 = from sale in sales
         where sale.Item == "Tea" & sale.ExpeditedShipping == false
         select sale;

//q4
var q4 = from sale in sales
         where sale.PricePerItem * sale.Quantity > 100
         select sale;

//q5
var q5 = from sale in sales
        where sale.Customer.ToLower().Contains("llc")
        select new
        {
            Item = sale.Item,
            TotalPrice = sale.PricePerItem * sale.Quantity,
            Shipping = sale.ExpeditedShipping ? sale.Address + " EXPEDITE" : sale.Address
        } into q5a
        orderby q5a.TotalPrice
        select q5a;


public class Sale
{
    public String Item { get; set; }
    public String Customer { get; set; }
    public double PricePerItem { get; set; }
    public int Quantity { get; set; }
    public String Address { get; set; }
    public bool ExpeditedShipping { get; set; }
}


