namespace SuperMarket.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

/* 
We have to map our collection of category models, that is provided by 
our category service, to a collection of category resources.
we will use a lib called AutoMapper to handle between objects.
*/
