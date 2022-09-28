using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Airbnb.Lottie;
using Android.Animation;

namespace News.Droid
{
    [Activity(Label = "News",
        Icon = "@mipmap/icon",
        Theme = "@style/nuevoTema",
        NoHistory = true,
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class SplashScreen : Activity, Animator.IAnimatorListener
    {
        bool isOpen = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
   
            SetContentView(Resource.Drawable.SplashAnimation);

            var animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            animationView.AddAnimatorListener(this);

        }

        public void OnAnimationCancel(Animator animator)
        {
        }

        public void OnAnimationStart(Animator animator)
        {
        }

        public void OnAnimationEnd(Animator animator)
        {

        }

        public void OnAnimationRepeat(Animator animator)
        {
            if(!isOpen)
            {
                isOpen = true;
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }
        }
    }
}