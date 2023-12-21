using EFConsole.EntityFramework;
using EFConsole.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

using (var _context=new AppDbContext())
        {
    //var category = new Category { Name = "Beyaz Eşya" };
    //category.Products.Add(new() { Name = "Buzdolabı", Price = 12500, Stock = 21, ProductFeature = new() { Height = 70, Weight = 114 } });
    //category.Products.Add(new() { Name = "LCD Televizyon", Price = 14250, Stock = 112, ProductFeature = new() { Height = 40, Weight = 30 } });

    //_context.Categories.Add(category);
    //_context.SaveChanges();

    // Eager loading Include mantığında olan
    //var productList= await _context.Products.Include(a=>a.Category).Include(a=>a.ProductFeature).ToListAsync();

    #region EagerLoading
    //var productList = _context.Categories.Include(a => a.Products).ThenInclude(a => a.ProductFeature).ToListAsync();

    //StringBuilder stringBuilder = new StringBuilder();

    //productList.Result.ForEach(p =>
    //   {

    //   stringBuilder.AppendLine($"************Category : { p.Name}**************");
    //   stringBuilder.AppendLine(" ");

    //       p.Products.ForEach(a =>
    //       {
    //           stringBuilder.AppendLine($"--Products--");
    //           stringBuilder.AppendLine($"Name:{a.Name} Price:{a.Price} Stock:{a.Stock} Heigt:{a.ProductFeature.Height} Weight:{a.ProductFeature.Height}");
    //           stringBuilder.AppendLine($"--------------------------------------------");

    //       });


    //            //Console.WriteLine($"Category:{p.Category.Name} - Product Name:{p.Name} - Price:{p.Price} - Stock:{p.Stock} - Heigt:{p.ProductFeature.Height}" );
    //        });

    //        Console.WriteLine(stringBuilder);

    #endregion
    #region ExplicitLoading

    //var category =_context.Categories.FirstOrDefault();
    //var product= _context.Products.FirstOrDefault();

    //if (true)
    //{
    //    //burada ihtiyacım oldu categorinin ürünlerine
    //    _context.Entry(category).Collection(x=>x.Products).Load();

    //    category.Products.ForEach(a =>
    //    {
    //        Console.WriteLine($"Product Name:{a.Name}");
    //    });




    //    //ilk etapta ihityacım yoktu ama burada produc'ın product feauture'larına ihityacım oldu

    //    //birebir ilişki olduğu için Reference kullandığı yukarıda bire çok ilşki olduğu için ve kategorilerin Ürün collection'ı olduğu için Collection kullandım.
    //    _context.Entry(product).Reference(x=>x.ProductFeature).Load();

    //    Console.WriteLine($"Product Name:{product.Name}-- Heigt:{product.ProductFeature.Height}");
    
    #endregion
    #region LazyLoading

    //LazyLoading yapılabilinmesi için 1. Microsoft.EntityFrameworkCore.Proxies yüklenmesi lazım 2.Ardıntan OnConfiguring Methodunda UseLayLoadingProxies() 
    //3. son olarak Navigation Properties 'lere Virtual Keyword'u eklenmelidir.
    //Veri tabanına 2 kez gidip sorgu atıyor.hem categori de hemde categorinin ürünlerini getirirken.
    var category = await _context.Categories.FirstAsync();
    var products=category.Products;

    products.ForEach(p =>
    {
        Console.WriteLine("P.Name:" + p.Name);
    });

}

    #endregion


