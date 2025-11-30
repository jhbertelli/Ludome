export interface SearchGamesInput {
    search: string
    categoryIds: string[]
    sortBy: 'reviews' | 'nameAsc' | 'nameDesc'
}
