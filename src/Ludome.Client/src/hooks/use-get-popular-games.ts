import { useQuery } from '@tanstack/react-query'
import { GamesService } from 'services/games-service'
import { GetPopularGamesInput } from 'services/types'

export const useGetPopularGames = (filter: GetPopularGamesInput) =>
    useQuery({
        queryFn: () => GamesService.getPopular(filter),
        select: (response) => response.data,
        queryKey: ['get_popular_games', filter],
    })
