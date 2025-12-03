import { useMutation } from '@tanstack/react-query'
import { LOCAL_STORAGE_KEYS } from 'constants/local-storage'
import { pathTo } from 'constants/paths'
import { useLocalStorage } from 'react-use'
import { AuthService } from 'services/auth-service'
import { configureAuthorizationHeader } from 'services/axios'

export const useLogout = () => {
    const [, setLocalStorage] = useLocalStorage(LOCAL_STORAGE_KEYS.JWT_TOKEN, '', { raw: true })

    return useMutation({
        mutationFn: AuthService.logout,
        onSuccess: () => {
            setLocalStorage('')
            configureAuthorizationHeader()
            location.pathname = pathTo.login
        },
    })
}
