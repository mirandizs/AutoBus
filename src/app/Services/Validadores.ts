import { AbstractControl, ValidationErrors } from "@angular/forms";


export class Validadores {
    static SenhaForte(Input: AbstractControl): ValidationErrors | null {
        const valor: string = Input.value || '';
        const erros: any = {};
    
        if (!/[a-z]/.test(valor)) {
          erros['minuscula'] = true;
        }
    
        if (!/[A-Z]/.test(valor)) {
          erros['maiuscula'] = true;
        }
    
        if (!/[0-9]/.test(valor)) {
          erros['numero'] = true;
        }
    
        if (valor.length < 8) {
          erros['caracteres'] = true;
        }
    
        return Object.keys(erros).length > 0 ? erros : null;
    }
}