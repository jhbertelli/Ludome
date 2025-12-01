import { useQuery } from '@tanstack/react-query'
import { GamesService } from 'services/games-service'

export const useGetGameRatings = (id: string) =>
    useQuery({
        queryFn: () => GamesService.getGameRatings(id),
        select: (response) => response.data,
        queryKey: ['get_game_ratings', id],
    })
