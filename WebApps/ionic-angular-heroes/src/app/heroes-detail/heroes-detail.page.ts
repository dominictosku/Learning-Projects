import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import {Hero} from "../classes/hero";
import {ActivatedRoute} from "@angular/router";
import {HeroService} from "../services/hero.service";
import { Location } from '@angular/common';

@Component({
  selector: 'app-heroes-detail',
  templateUrl: './heroes-detail.page.html',
  styleUrls: ['./heroes-detail.page.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule]
})
export class HeroesDetailPage implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private heroService: HeroService,
    private location: Location
  ) {}

  hero: Hero | undefined;

  ngOnInit(): void {
    this.getHero();
  }

  save(): void {
    if (this.hero) {
      this.heroService.updateHero(this.hero)
        .subscribe(() => this.goBack());
    }
  }

  getHero(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.heroService.getHero(id)
      .subscribe((hero: Hero | undefined) => this.hero = hero);
  }

  goBack(): void {
    this.location.back();
  }
}
