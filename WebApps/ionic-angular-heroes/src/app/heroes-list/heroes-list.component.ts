import {Component, EventEmitter, Input, Output} from '@angular/core';
import {RouterLink} from "@angular/router";
import {NgIf} from "@angular/common";
import {Hero} from "../classes/hero";

@Component({
  selector: 'app-heroes-list',
  standalone: true,
  imports: [
    RouterLink,
    NgIf
  ],
  templateUrl: './heroes-list.component.html',
  styleUrl: './heroes-list.component.scss'
})
export class HeroesListComponent {
  @Input() hero!: Hero

  @Output() sendId = new EventEmitter<number>();

  navigateToDetails(value: number) {
    this.sendId.emit(value);
  }
}
