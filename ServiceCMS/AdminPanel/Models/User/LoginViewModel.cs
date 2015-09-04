using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPanel.Models.User
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login", ResourceType = typeof(Modules.Resources.Presentation))]
        public string LandingPageLogin { get; set; }

        [Required]
        [Display(Name = "Password", ResourceType = typeof(Modules.Resources.Presentation))]
        public string LandingPagePassword { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Modules.Resources.Presentation))]
        public bool LandingPageRememberMe { get; set; }
    }
}