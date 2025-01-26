import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./tabs/tabs.routes').then((m) => m.routes),
  },
  {
    path: 'dashboard',
    loadComponent: () => import('./dashboard/dashboard.page').then( m => m.DashboardPage)
  },
  {
    path: 'dashboard',
    loadComponent: () => import('./dashboard/dashboard.page').then( m => m.DashboardPage)
  },
  {
    path: 'heroes',
    loadComponent: () => import('./heroes/heroes.page').then( m => m.HeroesPage)
  },
  {
    path: 'detail/:id',
    loadComponent: () => import('./heroes-detail/heroes-detail.page').then(m => m.HeroesDetailPage)
  },
  {
    path: 'heroes-detail',
    loadComponent: () => import('./heroes-detail/heroes-detail.page').then( m => m.HeroesDetailPage)
  },
  {
    path: 'settings',
    loadComponent: () => import('./settings/settings.page').then( m => m.SettingsPage)
  },
];
