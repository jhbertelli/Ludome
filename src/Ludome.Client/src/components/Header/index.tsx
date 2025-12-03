import { useLogout } from 'hooks/use-logout'
import { LogOut } from 'react-feather'

export const Header = () => {
    const logout = useLogout()

    return (
        <header className="bg-purple-700 text-white shadow-md">
            <div className="container mx-auto px-6 py-4 flex justify-between items-center">
                <div className="flex items-center gap-3">
                    <img src="/react.svg" alt="Ludome Logo" className="h-8 w-8 invert brightness-0 filter" />
                    <h1 className="text-xl font-bold tracking-wide">Ludome</h1>
                </div>
                <button
                    className="hover:bg-purple-600 p-2 rounded-full transition-colors"
                    onClick={() => logout.mutate()}
                >
                    <LogOut />
                </button>
            </div>
        </header>
    )
}
