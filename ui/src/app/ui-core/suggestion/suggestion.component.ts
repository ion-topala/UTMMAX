import {ChangeDetectionStrategy, Component, Input} from '@angular/core';

@Component({
  selector: 'app-suggestion',
  templateUrl: './suggestion.component.html',
  styleUrls: ['./suggestion.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SuggestionComponent {
  @Input()
  public classNames: string;

  @Input()
  public type: 'suggestion' | 'safe' | 'critical' | 'calm' | 'tip' | 'warn' = 'suggestion';
}
