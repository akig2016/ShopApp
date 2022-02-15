
using com.application.models;
using System.Collections.Generic;
using UnityEngine;

public static class DataSimulator 
{
    public static string SimulateProductCatalouge()
    {
        string desc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
        var productCatalogue = new ProductCatalogue();
        productCatalogue.Products = new List<ProductModel>();
        var p1 = new ProductModel("1", "HMTG-G9052 Original Gold Plated Day",
            "https://rukminim1.flixcart.com/image/714/857/ke0a7ww0-0/watch/h/e/8/hmtg-g9052-original-gold-plated-day-date-watch-golden-chain-hrnt-original-imafusbxnhhrybxr.jpeg?q=50",
            416, "WATCH", "MALE", desc);
        productCatalogue.Products.Add(p1);
        var p2 = new ProductModel("2", "7072-BLACK GOLD PLATED",
            "https://rukminim1.flixcart.com/image/880/1056/ks6ef0w0/watch/d/e/b/7072-black-hmtr-original-imag5syhzsxcwtjm.jpeg?q=50",
            399, "WATCH", "FEMALE", desc);
        productCatalogue.Products.Add(p2);
        var p3 = new ProductModel("3", "Chhota bheem Digital Light",
            "https://rukminim1.flixcart.com/image/880/1056/kxkqavk0/watch/c/t/t/1-chhota-bheem-digital-light-24-images-chhota-bheem-projector-original-imag9ztah4ykgqgp.jpeg?q=50",
            200, "WATCH", "KIDS", desc);
        productCatalogue.Products.Add(p3);


        var p4 = new ProductModel("4", "Cotton Polyester Blend shirt",
           "https://rukminim1.flixcart.com/image/580/696/kwxv98w0/fabric/o/c/t/no-2-25-m-unstitched-na-hh-3348-ok-livecraft-original-imag9g3bpvmatyan.jpeg?q=50",
           500, "CLOTH", "MALE", desc);
        productCatalogue.Products.Add(p4);
        var p5 = new ProductModel("5", "FILA printed shirt",
            "https://rukminim1.flixcart.com/image/580/696/kfoapow0-0/t-shirt/i/f/7/l-12008361-fila-original-imafw2k4agxbzg78.jpeg?q=50",
            800, "CLOTH", "FEMALE", desc);
        productCatalogue.Products.Add(p5);
        var p6 = new ProductModel("6", "Chhota bheem shirt",
            "https://rukminim1.flixcart.com/image/580/696/kri3xjk0/kids-t-shirt/f/b/q/3-4-years-bheem-krishna-riva-printography-original-imag5a2fagkufcpc.jpeg?q=50",
            200, "CLOTH", "KIDS", desc);
        productCatalogue.Products.Add(p6);

        var p7 = new ProductModel("7", "gold-plated-chain-for-boys",
           "https://rukminim1.flixcart.com/image/580/696/ku1k4280/necklace-chain/v/6/q/1-styles-gold-plated-chain-for-boys-and-men-chain-brandsoon-original-imag797xqgbdvzxf.jpeg?q=50",
           500, "JEWELERY", "MALE", desc);
        productCatalogue.Products.Add(p7);
        var p8 = new ProductModel("8", "gold plated jewel set",
            "https://rukminim1.flixcart.com/image/580/696/kwwfte80/jewellery-set/c/7/g/na-na-80035gr-saiyoni-original-imag9hyj2hudhkwh.jpeg?q=50",
            800, "JEWELERY", "FEMALE", desc);
        productCatalogue.Products.Add(p8);
        var p9 = new ProductModel("9", "Acrylic Jewel Set",
            "https://rukminim1.flixcart.com/image/580/696/j2ur3ww0/jewellery-set/q/h/z/fjs-b001-el-regalo-original-imaeuyw9zjzjz7za.jpeg?q=50",
            200, "JEWELERY", "KIDS", desc);
        productCatalogue.Products.Add(p9);

        productCatalogue.Catogries = new List<Category>();
        productCatalogue.Catogries.Add(new Category("WATCH", new List<string> { "MALE", "FEMALE", "KIDS" }));
        productCatalogue.Catogries.Add(new Category("CLOTH", new List<string> { "MALE", "FEMALE", "KIDS" }));
        productCatalogue.Catogries.Add(new Category("JEWELERY", new List<string> { "MALE", "FEMALE", "KIDS" }));
        string data = JsonUtility.ToJson(productCatalogue);
        Debug.Log(data);
        return data;
    }
}
