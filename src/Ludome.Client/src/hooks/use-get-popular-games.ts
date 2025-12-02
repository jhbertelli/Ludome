import { useQuery } from '@tanstack/react-query'
import { GamesService } from 'services/games-service'

export const useGetPopularGames = ({ enabled }: { enabled?: boolean }) =>
    useQuery({
        queryFn: () => GamesService.getPopular({ categoryIds: [] }),
        select: (response) => response.data,
        queryKey: ['get_popular_games'],
        enabled,
    })
