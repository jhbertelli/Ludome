import { zodResolver } from '@hookform/resolvers/zod'
import { PasswordInput, TextInput, Title } from '@mantine/core'
import { Button } from 'components/Button'
import { pathTo } from 'constants/paths'
import { useRegister } from 'hooks/use-register'
import { SubmitHandler, useForm } from 'react-hook-form'
import { useTitle } from 'react-use'
import { registerSchema, RegisterSchema } from 'schemas/auth'

export const RegisterPage = () => {
    const registerUser = useRegister()

    useTitle('Cadastro')

    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<RegisterSchema>({
        resolver: zodResolver(registerSchema),
    })

    const onSubmit: SubmitHandler<RegisterSchema> = async (data) => await registerUser.mutateAsync(data)

    return (
        <form onSubmit={handleSubmit(onSubmit)} className="h-full flex flex-col justify-between">
            <div className="flex flex-col gap-4">
                <Title className="text-center">Cadastro</Title>

                <TextInput
                    label="Nome"
                    placeholder="Insira o seu nome..."
                    {...register('nickname')}
                    error={errors.nickname?.message}
                    withAsterisk
                />

                <TextInput
                    type="email"
                    label="E-mail"
                    placeholder="Insira o seu endereço de e-mail..."
                    {...register('email')}
                    error={errors.email?.message}
                    withAsterisk
                />

                <PasswordInput
                    label="Senha"
                    placeholder="Insira a sua senha..."
                    {...register('password')}
                    error={errors.password?.message}
                    withAsterisk
                />

                <PasswordInput
                    label="Repita sua senha"
                    placeholder="Insira novamente a sua senha..."
                    {...register('repeatPassword')}
                    error={errors.repeatPassword?.message}
                    withAsterisk
                />
            </div>

            <div className="flex flex-col gap-4">
                <Button variant="default" path={pathTo.login} fullWidth>
                    Já possui uma conta?
                </Button>

                <Button type="submit" color="violet">
                    Cadastrar
                </Button>
            </div>
        </form>
    )
}
