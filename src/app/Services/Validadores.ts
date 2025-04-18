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

    static ConfirmacaoPassword (Input: AbstractControl): ValidationErrors | null {
      const Form = Input.parent

      if (Form){
        const InputPassword = Form.get('password');
        const InputConfirmacaoPassword = Form.get('confirm_password');
    
        if (InputPassword && InputConfirmacaoPassword) {
          const error = InputPassword.value != InputConfirmacaoPassword.value ? { PasswordNaoIgual: true } : null;
          
          InputConfirmacaoPassword.setErrors(error);

          const InputSelecionadoEConfirmacao = Input == InputConfirmacaoPassword;

          return InputSelecionadoEConfirmacao ? error : null; // Se o input nao for o de confirmacao, retorna null
        }else{
          console.warn('Um dos campos não existe no formulário. Verifica se os nomes estão corretos (formControlname).');
        }
      }
  
      return null;
    };
}