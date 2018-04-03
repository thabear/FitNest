using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Views;

namespace FitNest.Droid
{
    [Activity(Label = "FitNest", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        //int count = 1;
        private DrawerLayout mDrawerLayout;
        private ActionBarDrawerToggle mActionBarDrawerToggle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ActivityMain);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.myButton);
            //button.Click += delegate { button.Text = $"{count++} clicks!"; };

            Android.Support.V7.Widget.Toolbar mToolbar = this.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            Android.Support.Design.Widget.NavigationView mNavigationView = FindViewById<Android.Support.Design.Widget.NavigationView>(Resource.Id.nav_view);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mActionBarDrawerToggle = new ActionBarDrawerToggle(this, mDrawerLayout, Resource.String.open, Resource.String.close);

            mDrawerLayout.AddDrawerListener(mActionBarDrawerToggle);
            mActionBarDrawerToggle.SyncState();

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SelectMenuItem(mNavigationView);

            

        }

        public void SelectMenuItem(Android.Support.Design.Widget.NavigationView navView)
        {
            navView.NavigationItemSelected += (sender, e) =>
            {
                //FragmentTransaction transaction = this.FragmentManager.BeginTransaction();
                Fragment fragment = null;
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.tab_news:
                        SetTitle(Resource.String.news);
                        //transaction.Add(Resource.Id.container_fragment, new FragmentNews());
                        //transaction.Commit();
                        fragment = new FragmentNews();
                        break;
                    case Resource.Id.tab_workout_log:
                        SetTitle(Resource.String.workout_log);
                        //transaction.Add(Resource.Id.container_fragment, new FragmentWorkoutLog());
                        //transaction.Commit();
                        fragment = new FragmentWorkoutLog();
                        break;
                    case Resource.Id.tab_meal_tracking:
                        SetTitle(Resource.String.meal_tracking);
                        //transaction.Add(Resource.Id.container_fragment, new FragmentMealTracking());
                        //transaction.Commit();
                        fragment = new FragmentMealTracking();
                        break;
                    case Resource.Id.tab_progress:
                        SetTitle(Resource.String.progress);
                        //transaction.Add(Resource.Id.container_fragment, new FragmentProgress());
                        //transaction.Commit();
                        fragment = new FragmentProgress();
                        break;
                }
                FragmentManager manager = FragmentManager;
                FragmentTransaction transaction = manager.BeginTransaction();
                transaction.Replace(Resource.Id.container_fragment, fragment);
                transaction.Commit();

                mDrawerLayout.CloseDrawers();
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (mActionBarDrawerToggle.OnOptionsItemSelected(item))
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}

