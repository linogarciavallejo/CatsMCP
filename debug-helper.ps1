#!/usr/bin/env pwsh
param(
    [string]$Method = "tools/list",
    [hashtable]$Params = @{}
)

# Create MCP JSON-RPC message
$message = @{
    jsonrpc = "2.0"
    id = 1
    method = $Method
    params = $Params
} | ConvertTo-Json -Depth 10 -Compress

Write-Host "🔍 Debug Helper - Send MCP Message" -ForegroundColor Green
Write-Host "=" * 50 -ForegroundColor Gray
Write-Host "Method: $Method" -ForegroundColor Cyan
Write-Host "Message: $message" -ForegroundColor Yellow
Write-Host ""

Write-Host "📝 Instructions:" -ForegroundColor Yellow
Write-Host "1. Start CatsMCP.WebApi in Visual Studio Debug mode (F5)"
Write-Host "2. When the server starts and shows 'reading messages', paste this JSON:"
Write-Host ""
Write-Host "📋 Copy this JSON message:" -ForegroundColor Green
Write-Host $message -ForegroundColor White
Write-Host ""
Write-Host "3. Paste it into the Debug Console or Terminal where the server is running"
Write-Host "4. Press Enter to send the message"
Write-Host ""
Write-Host "🎯 Expected behavior:" -ForegroundColor Cyan
Write-Host "- Your breakpoints should be hit in CatTools.cs"
Write-Host "- You can inspect variables and step through the code"
Write-Host "- You'll see the actual response being generated"
Write-Host ""

# Also save to clipboard if possible
try {
    $message | Set-Clipboard
    Write-Host "✅ Message copied to clipboard!" -ForegroundColor Green
} catch {
    Write-Host "ℹ️  Clipboard copy failed, but message is displayed above" -ForegroundColor Gray
}

Write-Host ""
Write-Host "🧪 Test Messages:" -ForegroundColor Yellow
Write-Host "List tools:  .\debug-helper.ps1 -Method 'tools/list'"
Write-Host "Get cats:    .\debug-helper.ps1 -Method 'tools/call' -Params @{name='GetCats'; arguments=@{}}"
Write-Host "Get cat:     .\debug-helper.ps1 -Method 'tools/call' -Params @{name='GetCat'; arguments=@{name='Fluffy'}}"
