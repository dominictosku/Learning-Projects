import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HeroesDetailPage } from './heroes-detail.page';

describe('HeroesDetailPage', () => {
  let component: HeroesDetailPage;
  let fixture: ComponentFixture<HeroesDetailPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(HeroesDetailPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
