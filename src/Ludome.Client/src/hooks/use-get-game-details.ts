import { useQuery } from '@tanstack/react-query'
import { GamesService } from 'services/games-service'

export const useGetGameDetails = (id: string) =>
    useQuery({
        queryFn: () => GamesService.getGameDetails(id),
        select: (response) => response.data,
        queryKey: ['get_game_details', id],
    })
