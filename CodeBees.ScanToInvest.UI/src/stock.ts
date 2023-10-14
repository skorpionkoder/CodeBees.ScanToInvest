export interface Address {
  address1: string
  city: string
  state: string
  postal_code: string
}

export interface Branding {
  logo_Url: string
  icon_url: string
}

export interface Results {
  ticker: string
  name: string
  market: string
  locale: string
  primary_exchange: string
  type: string
  active: string
  currency_name: string
  cik: string
  composite_figi: string
  share_class_figi: string
  market_cap: string
  phone_number: string
  address: Address
  description: string
  sic_code: string
  sic_description: string
  ticker_root: string
  homepage_Url: string
  total_employees: number
  list_date: string
  branding: Branding
  share_class_shares_outstanding: number
  weighted_shares_outstanding: number
  round_lot: number
}

export interface StockDetailResponse {
  request_id: string
  results: Results
  status: string
}
