import {AfterViewInit, Component, ElementRef, EventEmitter, forwardRef, Input, Output, ViewChild} from '@angular/core';
import {ControlValueAccessor, NG_VALUE_ACCESSOR} from "@angular/forms";

@Component({
  selector: 'search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SearchBarComponent),
      multi: true
    }
  ]
})
export class SearchBarComponent implements ControlValueAccessor, AfterViewInit {
  @Input()
  public placeholder: string = 'Type to search..';

  @Input()
  public set value(value: string) {
    this.valueField = value;
  }

  @Input()
  public theme: 'default' | 'inverted' = 'default';

  @Input()
  public hint: string;

  @Input()
  public grabFocus: boolean;

  @Input()
  public disabled: boolean;

  @Output()
  public onChange = new EventEmitter<string>();

  @Output()
  public onClick = new EventEmitter<string>();

  @ViewChild('inputElement')
  public inputElement: ElementRef;

  public valueField: string = null;

  public ngAfterViewInit(): void {
    if (this.grabFocus) {
      this.inputElement?.nativeElement.focus();
    }
  }

  public registerOnChange(fn: any): void {
    this.onChange.subscribe(fn);
  }

  public registerOnTouched(fn: any): void {
    this.onChange.subscribe(fn);
  }

  public writeValue(outerValue: string): void {
    this.valueField = outerValue;
  }

  public updateValue(event: KeyboardEvent): void {
    const inputValue = (event.target as HTMLInputElement).value;
    this.valueField = inputValue;
    this.onChange.emit(inputValue);
  }
}
