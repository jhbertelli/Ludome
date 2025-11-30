import { zodResolver } from '@hookform/resolvers/zod'
import { PasswordInput, TextInput, Title } from '@mantine/core'
import { Button } from 'components/Button'
import { pathTo } from 'constants/paths'
import { useLogin } from 'hooks/use-login'
import { SubmitHandler, useForm } from 'react-hook-form'
import { useTitle } from 'react-use'
import { LoginSchema, loginSchema } from 'schemas/auth'

export const LoginPage = () => {
    const login = useLogin()

    useTitle('Login')

    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<LoginSchema>({
        resolver: zodResolver(loginSchema),
    })

    const onSubmit: SubmitHandler<LoginSchema> = async (data) => await login.mutateAsync(data)

    return (
        <form onSubmit={handleSubmit(onSubmit)} className="h-full flex flex-col justify-between mx-auto p-6 max-w-xl">
            <div className="flex flex-col gap-4">
                <Title className="text-center">Login</Title>

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
            </div>

            <div className="flex flex-col gap-4">
                <Button variant="default" path={pathTo.register} fullWidth>
                    Não possui uma conta?
                </Button>

                <Button type="submit" color="violet">
                    Login
                </Button>
            </div>
        </form>
    )
}
