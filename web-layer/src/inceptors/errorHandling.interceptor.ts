import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';


export const errorInterceptor: HttpInterceptorFn = (req, next) => {
    return next(req).pipe(
        catchError((error: HttpErrorResponse) => {
            let errorMessage: string;

            if (error.error instanceof ErrorEvent) {
                // Client-side error
                errorMessage = error.error.message;
            } else {
                // Server-side error
                if (typeof error.error === 'string') {
                    try {
                        const errorBody = JSON.parse(error.error);
                        errorMessage = errorBody.title || errorBody.message || 'Unknown server error';
                    } catch (e) {
                        errorMessage = error.error; // Use the string directly if it's not JSON
                    }
                } else if (error.error && typeof error.error === 'object') {
                    errorMessage = error.error.title || error.error.message || JSON.stringify(error.error);
                } else {
                    errorMessage = error.message || 'Unknown server error';
                }
            }

            // Create a new error response with the error message directly in the 'error' property
            const errorResponse = new HttpErrorResponse({
                error: errorMessage.toString(),
            });

            return throwError(() => errorResponse);
        })
    );
}