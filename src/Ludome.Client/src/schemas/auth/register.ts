import { z } from 'zod'

// Rules:
// - Should contain at least 1 lowercase letter
// - Should contain at least 1 number
// - Should contain at least 1 special character: !@-#.$%^&*
// - Should contain at least 8 characters
const PASSWORD_REGEX = /^(?=.*[a-z])(?=.*[0-9])(?=.*[!@\-#.$%^&*])[a-zA-Z0-9!@\-#.$%^&*]{8,}$/

export const registerSchema = z
    .object({
        email: z.email('Insira um e-mail válido'),
        nickname: z.string().nonempty('Insira um apelido'),
        password: z
            .string()
            .nonempty('Insira uma senha')
            .regex(
                PASSWORD_REGEX,
                `Senhas devem conter pelo menos: 1 letra minúscula, 1 número, 1 caractere especial (!@-#.$%^&*) e tamanho mínimo de 8 caracteres`
            ),
        repeatPassword: z.string().nonempty('Insira uma senha'),
    })
    .refine((schema) => schema.password === schema.repeatPassword, {
        message: 'As senhas devem ser iguais',
        path: ['repeatPassword'],
    })

export type RegisterSchema = z.infer<typeof registerSchema>
