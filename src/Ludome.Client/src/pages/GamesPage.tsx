import { GamesGrid } from 'components/GameGrid'
import { Header } from 'components/Header'
import { useGetPopularGames } from 'hooks/use-get-popular-games'
import { useForm } from 'react-hook-form'
import { GetPopularGamesInput } from 'services/types'

const DEFAULT_SEARCH_VALUES: GetPopularGamesInput = {
    categoryIds: [],
}

export default function GamesPage() {
    const { register, watch } = useForm<GetPopularGamesInput>({
        defaultValues: DEFAULT_SEARCH_VALUES,
    })

    const formValues = watch()

    const { data: games } = useGetPopularGames(formValues)

    return (
        <div className="min-h-screen font-sans">
            <Header />

            <div className="container mx-auto px-6 py-8 flex flex-col md:flex-row gap-8">
                <main className="flex-1">
                    <h2 className="text-3xl font-bold mb-6">Jogos populares</h2>

                    {games && <GamesGrid games={games} />}
                </main>

                <aside className="w-full md:w-72 shrink-0">
                    <div className="border border-gray-200 rounded-lg p-6 sticky top-6 h-full">
                        <form className="flex flex-col gap-8">
                            <div>
                                <input
                                    type="text"
                                    placeholder="Insira um termo de busca..."
                                    className="w-full px-3 py-2 border border-gray-300 rounded-md text-sm focus:outline-none focus:ring-1 focus:ring-purple-500 bg-gray-50 text-gray-700"
                                    // {...register('search')}
                                />
                            </div>

                            {/* <div>
                                <h3 className="font-semibold text-gray-800 mb-3 text-sm">Filtrar categorias:</h3>
                                <div className="space-y-2">
                                    {['Ação', 'Aventura', 'Plataforma', 'Tiro', 'Quebra-cabeça'].map((category) => (
                                        <label key={category} className="flex items-center gap-3 cursor-pointer group">
                                            <div className="relative flex items-center">
                                                <input
                                                    type="checkbox"
                                                    value={category}
                                                    className="peer appearance-none w-4 h-4 border border-gray-400 rounded-sm bg-white checked:bg-gray-800 checked:border-gray-800 focus:outline-none transition-colors"
                                                    {...register('categories')}
                                                />
                                                <svg
                                                    className="absolute w-3 h-3 text-white pointer-events-none hidden peer-checked:block left-0.5"
                                                    xmlns="http://www.w3.org/2000/svg"
                                                    viewBox="0 0 24 24"
                                                    fill="none"
                                                    stroke="currentColor"
                                                    strokeWidth="4"
                                                    strokeLinecap="round"
                                                    strokeLinejoin="round"
                                                >
                                                    <polyline points="20 6 9 17 4 12"></polyline>
                                                </svg>
                                            </div>
                                            <span className="text-sm text-gray-700 group-hover:text-gray-900">
                                                {category}
                                            </span>
                                        </label>
                                    ))}
                                </div>
                            </div> */}

                            {/* <div>
                                <h3 className="font-semibold text-gray-800 mb-3 text-sm">Ordenar por:</h3>
                                <div className="space-y-2">
                                    <label className="flex items-center gap-3 cursor-pointer group">
                                        <div className="relative flex items-center">
                                            <input
                                                type="radio"
                                                value="reviews"
                                                className="peer appearance-none w-4 h-4 border border-gray-400 rounded-full bg-white checked:border-gray-900 checked:border-[5px] transition-all"
                                                {...register('sortBy')}
                                            />
                                        </div>
                                        <span className="text-sm text-gray-700 group-hover:text-gray-900">
                                            Quantidade de avaliações
                                        </span>
                                    </label>

                                    <label className="flex items-center gap-3 cursor-pointer group">
                                        <div className="relative flex items-center">
                                            <input
                                                type="radio"
                                                value="nameAsc"
                                                className="peer appearance-none w-4 h-4 border border-gray-400 rounded-full bg-white checked:border-gray-900 checked:border-[5px] transition-all"
                                                {...register('sortBy')}
                                            />
                                        </div>
                                        <span className="text-sm text-gray-700 group-hover:text-gray-900">
                                            Nome (A-Z)
                                        </span>
                                    </label>

                                    <label className="flex items-center gap-3 cursor-pointer group">
                                        <div className="relative flex items-center">
                                            <input
                                                type="radio"
                                                value="nameDesc"
                                                className="peer appearance-none w-4 h-4 border border-gray-400 rounded-full bg-white checked:border-gray-900 checked:border-[5px] transition-all"
                                                {...register('sortBy')}
                                            />
                                        </div>
                                        <span className="text-sm text-gray-700 group-hover:text-gray-900">
                                            Nome (Z-A)
                                        </span>
                                    </label>
                                </div>
                            </div> */}
                        </form>
                    </div>
                </aside>
            </div>
        </div>
    )
}
