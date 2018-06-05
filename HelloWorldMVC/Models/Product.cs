using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;
using System.IO;
using System.Data.Entity;

namespace HelloWorldMVC.Models
{
    public class Product

    
    {

        public int Id { get; set; }
      //  public int ProductId { get; set; } equivalent au dessus
      // pour qu entity framework fonctionne, il faut ,un champ id de type int, ou une classe ex:"ProductId" de type int


        [Required(ErrorMessage = "La référence est requise")]
        [StringLength(8, ErrorMessage = "La réference est trop longue")]
        [Display(Name = "Référence produit")]
        public string Reference//accesseur
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Le nom du produit est obligatoire")]
        //ajoute l attribut reuis
        [StringLength(64, ErrorMessage = "La réference est trop longue")]
        //condition de validation
        [Display(Name = "Nom du produit")]
        //change l affichage du label dans la vue
        public string ProductName//accesseur
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Le prix est requis")]
        [Display(Name = "Prix TTC")]
        public double ProductPrice//accesseur
        {
            get;
            set;
        }


        [Display(Name = "Description du produit")]
        public string ProductDescription//accesseur
        {
            get;
            set;
        }

        public Product()//constructeur ppar defaut
        {

        }

        public Product(string _reference)//constructeur
        {
            this.Reference = _reference;
        }

        public string GetImagePath()
        {
            return "Content/product/" + Reference + ".jpg";
        }

        public string Getimage()
        {
            string path = HttpContext.Current.Server.MapPath("/Content/product/" + Reference + ".jpg");
            if (File.Exists(path))//version complete
            {
                return "Content/product/" + Reference + ".jpg";
                /*retourne le chemin de fichiers ou stocker l image
            * et la renomme par sa referencepuis ajoute l extension .jpg*/
            }
            return "Content/no-image.jpg";

           
        }

        public string GetThumbnailPath()
        {
            return "Content/product/" + Reference + "_th.jpg";
        }

        public string GetThumbnail()
        {
            if (File.Exists(HttpContext.Current.Server.MapPath("~/" + GetThumbnailPath())))
                //version avec la method
            {
                return GetThumbnailPath();
                //chemin vignette
            }
            return "Content/no-image.jpg";
        }
    }
}