import { GameOutput } from 'services/types'
import { GameCard } from './GameCard'

interface GamesGridProps {
    games: GameOutput[]
}

export const GamesGrid = ({ games }: GamesGridProps) => {
    return (
        <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-6">
            {games.map((game) => (
                <GameCard {...game} />
            ))}
            {games.length === 0 && (
                <div className="col-span-full text-center py-12 text-gray-500">Nenhum jogo encontrado.</div>
            )}
        </div>
    )
}
