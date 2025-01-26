import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import {HeroesListComponent} from "../heroes-list/heroes-list.component";
import {HeroService} from "../services/hero.service";
import {MessageService} from "../services/message.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Hero} from "../classes/hero";

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.page.html',
  styleUrls: ['./heroes.page.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule, HeroesListComponent]
})
export class HeroesPage implements OnInit {
  constructor(private heroService: HeroService, private messageService: MessageService,
              private route: ActivatedRoute,
              private router: Router) { }

  heroes: Hero[] = [];

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    this.heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.heroService.addHero({ name } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }

  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero.id).subscribe();
  }

  navigate(id: number): void {
    this.router.navigate(['/detail', id]);
  }
}
