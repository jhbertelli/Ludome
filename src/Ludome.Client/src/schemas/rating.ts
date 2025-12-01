import { z } from 'zod'

export const ratingSchema = z.object({
    score: z.int(),
    comment: z.string().max(5000).optional(),
})

export type RatingsSchema = z.infer<typeof ratingSchema>
