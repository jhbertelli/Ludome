import { useMutation } from '@tanstack/react-query'
import { LOCAL_STORAGE_KEYS } from 'constants/local-storage'
import { pathTo } from 'constants/paths'
import { useLocalStorage } from 'react-use'
import { AuthService } from 'services/auth-service'
import { configureAuthorizationHeader } from 'services/axios'

export const useLogin = () => {
    const [, setLocalStorage] = useLocalStorage(LOCAL_STORAGE_KEYS.JWT_TOKEN, '', { raw: true })

    return useMutation({
        mutationFn: AuthService.login,
        onSuccess: ({ data: { jwtToken } }) => {
            setLocalStorage(jwtToken)
            configureAuthorizationHeader()
            location.pathname = pathTo.games
        },
    })
}
