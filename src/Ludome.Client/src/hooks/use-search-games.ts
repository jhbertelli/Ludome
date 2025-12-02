import { useQuery } from '@tanstack/react-query'
import { GamesService } from 'services/games-service'
import { SearchGamesInput } from 'services/types'

interface SearchGamesProps extends SearchGamesInput {
    enabled?: boolean
}

export const useSearchGames = ({ enabled, ...filter }: SearchGamesProps) =>
    useQuery({
        queryFn: () => GamesService.search(filter),
        select: (response) => response.data,
        queryKey: ['search_games', filter],
        enabled: enabled && !!filter.search,
    })
