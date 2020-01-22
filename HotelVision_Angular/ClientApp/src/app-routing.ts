import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './app/home/home.component';
import { QuicklinkModule, QuicklinkStrategy } from 'ngx-quicklink';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent, data: { routeState: 1 } },
  //{ path: 'post/:id/:slug', loadChildren: () => import('./post/post.module').then(m => m.PostModule), data: { routeState: 2 } },
  { path: '**', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: QuicklinkStrategy,
    useHash: true
  }),
    QuicklinkModule,
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
