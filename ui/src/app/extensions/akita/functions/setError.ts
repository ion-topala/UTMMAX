import { Store } from '@datorama/akita';
import { defer, MonoTypeOperatorFunction, tap } from 'rxjs';

export function setError<T>(store: Store): MonoTypeOperatorFunction<T> {
  return (source) =>
    defer(() => {
      return source.pipe(
        tap({
          error: (err: T) => store.setError(err),
        })
      );
    });
}
