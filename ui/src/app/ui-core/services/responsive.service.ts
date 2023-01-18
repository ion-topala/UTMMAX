import {BreakpointObserver} from '@angular/cdk/layout';
import {Injectable} from '@angular/core';
import {merge, Observable} from 'rxjs';
import {filter, map} from 'rxjs/operators';

export type ScreenSize = 'small' | 'medium' | 'large';

export enum Breakpoints {
  XSmall = '(max-width: 599.98px)',
  Small = '(min-width: 600px) and (max-width: 959.98px)',
  Medium = '(min-width: 960px) and (max-width: 1280px)',
  Large = '(min-width: 1281px) and (max-width: 1919.98px)',
  XLarge = '(min-width: 1920px)',
}

@Injectable({
  providedIn: 'root',
})
export class ResponsiveService {
  constructor(public breakpointObserver: BreakpointObserver) {
  }

  public isScreenSize(...screenSize: ScreenSize[]): Observable<boolean> {
    const breakPoints = screenSize.map(ResponsiveService.mapScreenSizeToBreakPoint).flatMap(it => it);

    return this.breakpointObserver.observe(breakPoints).pipe(map(value => value.matches));
  }

  public getScreenSize(): Observable<ScreenSize> {
    return merge(
      this.isScreenSize('small').pipe(
        filter(it => it),
        map(() => 'small' as ScreenSize),
      ),
      this.isScreenSize('medium').pipe(
        filter(it => it),
        map(() => 'medium' as ScreenSize),
      ),
      this.isScreenSize('large').pipe(
        filter(it => it),
        map(() => 'large' as ScreenSize),
      ),
    );
  }

  private static mapScreenSizeToBreakPoint(type: ScreenSize): string[] {
    switch (type) {
      case 'large':
        return [Breakpoints.Large, Breakpoints.XLarge];
      case 'medium':
        return [Breakpoints.Small, Breakpoints.Medium];
      case 'small':
        return [Breakpoints.XSmall];
      default:
        return [];
    }
  }
}
