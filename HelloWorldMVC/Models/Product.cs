using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;

namespace HelloWorldMVC.Models
{
    public class Product
    {
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
        [StringLength (64,ErrorMessage= "La réference est trop longue")]
        //condition de validation
        [ Display(Name =  "Nom du produit")]
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

        public string Getimage()
        {
            return "Content/product/" + Reference + ".jpg";
            /*retourne le chemin de fichiers ou stocker l image
             * et la renomme par sa referencepuis ajoute l extension .jpg*/
        }

        public string GetThumbnail()
        {
            return "Content/product/" + Reference + "_th.jpg";
            //chemin vignette
        }
    }
}