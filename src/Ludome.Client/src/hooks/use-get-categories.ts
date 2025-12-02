import { useQuery } from '@tanstack/react-query'
import { GamesService } from 'services/games-service'

export const useGetCategories = () =>
    useQuery({
        queryFn: GamesService.getCategories,
        select: (response) => response.data,
        queryKey: ['get_categories'],
    })
