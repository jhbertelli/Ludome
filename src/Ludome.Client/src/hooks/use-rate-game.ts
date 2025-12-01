import { useMutation, useQueryClient } from '@tanstack/react-query'
import { GamesService } from 'services/games-service'

export const useRateGame = () => {
    const queryClient = useQueryClient()

    return useMutation({
        mutationFn: GamesService.rateGame,
        onSuccess: (_, { gameId }) => {
            queryClient.invalidateQueries({ queryKey: ['get_game_ratings', gameId] })
            queryClient.invalidateQueries({ queryKey: ['get_game_details', gameId] })
        },
    })
}
