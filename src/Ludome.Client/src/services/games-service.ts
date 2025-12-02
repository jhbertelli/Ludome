import qs from 'qs'
import axios from 'services/axios'
import {
    CategoryOutput,
    DeleteRatingInput,
    GameDetailOutput,
    GameOutput,
    GetPopularGamesInput,
    RatingOutput,
    SearchGamesInput,
} from './types'
import { RatingInput } from './types/rating-input'

const servicePath = import.meta.env.VITE_BACKEND_URL + 'api/Game/'

export class GamesService {
    static async getPopular(input: GetPopularGamesInput) {
        return await axios.get<GameOutput[]>(`${servicePath}GetPopular`, {
            params: input,
            paramsSerializer: (params) => qs.stringify(params, { arrayFormat: 'repeat' }),
        })
    }

    static async search(input: SearchGamesInput) {
        return await axios.get<GameOutput[]>(`${servicePath}Search`, {
            params: input,
            paramsSerializer: (params) => qs.stringify(params, { arrayFormat: 'repeat' }),
        })
    }

    static async getGameDetails(id: string) {
        return await axios.get<GameDetailOutput>(`${servicePath}GetGameDetails/${id}`)
    }

    static async getGameRatings(id: string) {
        return await axios.get<RatingOutput[]>(`${servicePath}GetGameRatings/${id}`)
    }

    static async rateGame(input: RatingInput) {
        return await axios.post<void>(`${servicePath}RateGame`, input)
    }

    static async deleteRating(input: DeleteRatingInput) {
        return await axios.delete<void>(`${servicePath}DeleteRating`, { data: input })
    }

    static async getCategories() {
        return await axios.get<CategoryOutput[]>(`${servicePath}GetCategories`)
    }
}
